import { OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { Subscription } from 'rxjs';

import { IDateWrapper } from './date-wrapper';

export abstract class BaseComponent implements OnInit {

    @ViewChild('frm') public form: NgForm;

    public errorMessage: string;
    public isLoading: boolean = false;

    public recorded: IDateWrapper;

    public recordedMin: number;
    public recordedMax: number;

    private _request: Subscription = null;

    constructor(private _router: Router) {

        let now = new Date();

        this.recorded = {
            year: now.getFullYear(),
            month: now.getMonth() + 1,
            day: now.getDate()
        };

        this.recordedMax = now.getFullYear();
        this.recordedMin = this.recordedMax - 150;

    }

    ngOnInit() {
    }

    protected navigateTo(routeName: string) {
        this._router.navigate([routeName]);
    }

    protected submit(work) {
        this.doWorkLogError(() => {
          this.errorMessage = '';
    
          if (!this.validateDate(this.recorded)) {
            this.errorMessage = 'Please enter a valid date.'
            return;
          }
    
          if (this.form.valid) {
            this.isLoading = true;

            this._request = work();

            this.isLoading = false;
        }
        else {
          this.errorMessage = 'Please ensure all fields are completed correctly.'
        }
      });
    }

    protected validateDate(toValidate: IDateWrapper): boolean {
      var date = new Date(toValidate.year, toValidate.month - 1, toValidate.day);
  
      if ((date.getFullYear() == toValidate.year) && (date.getMonth() == toValidate.month - 1) && (date.getDate() == toValidate.day)) {
        return true;
      }
  
      return false;
    }
  
    protected doWorkLogError(work) {
      try {
        work();
      }
      catch (e) {
        this.errorMessage = 'An error has occurred. Please try again later.'
        this.isLoading = false;
  
        console.log(e);
      }
    }

    onCancel() {
      this.doWorkLogError(() => {
        if (this._request && this.isLoading) {
          this._request.unsubscribe();
          this.isLoading = false;
          this.errorMessage = 'Application cancelled.';
        }
      });
    }

}