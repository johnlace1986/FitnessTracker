import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

import { IDateWrapper } from '../models/date-wrapper';
import { IWeight } from '../models/weight';
import { ExerciseGroupService } from '../services/exercise-group.service';
import { Router } from '@angular/router';

@Component({
  selector: 'ft-new-exercise-group',
  templateUrl: './new-exercise-group.component.html',
  styleUrls: ['./new-exercise-group.component.css']
})
export class NewExerciseGroupComponent implements OnInit {

  @ViewChild('frm') public form: NgForm;

  public errorMessage: string;
  public successMessage: string;
  public isLoading: boolean = false;

  public weight: IWeight;
  public recorded: IDateWrapper;

  public recordedMin: number;
  public recordedMax: number;

  constructor(private _service: ExerciseGroupService, private _router: Router) {

    this.weight = {
      stone: 11,
      pounds: 5
    }

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

  onSubmit() {
    this.doWorkLogError(() => {
      this.successMessage = '';
      this.errorMessage = '';

      if (!this.validateDate(this.recorded)) {
        this.errorMessage = 'Please enter a valid date.'
        return;
      }

      if (this.form.valid) {
        this.isLoading = true;

        this._service.add(this.weight, this.recorded)          
          .subscribe(
            result => {
              console.log(result);
              this._router.navigate([''])
            },
            () => {
              this.errorMessage = 'Unable to process application. An error occurred on the server.';
              this.isLoading = false;
            });
      }
      else {
        this.errorMessage = 'Please ensure all fields are completed correctly.'
      }
    });
  }

private validateDate(toValidate: IDateWrapper): boolean {
  var date = new Date(toValidate.year, toValidate.month - 1, toValidate.day);

  if ((date.getFullYear() == toValidate.year) && (date.getMonth() == toValidate.month - 1) && (date.getDate() == toValidate.day)) {
    return true;
  }

  return false;
}

  private doWorkLogError(work) {
    try {
      work();
    }
    catch (e) {
      this.errorMessage = 'An error has occurred. Please try again later.'
      this.isLoading = false;

      console.log(e);
    }
  }

}
