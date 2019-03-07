import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

import { IDateWrapper } from '../models/date-wrapper';
import { IWeight } from '../models/weight';
import { ExerciseGroupService } from '../services/exercise-group.service';
import { Router } from '@angular/router';
import { BaseComponent } from '../models/base.component';

@Component({
  selector: 'ft-new-exercise-group',
  templateUrl: './new-exercise-group.component.html',
  styleUrls: ['./new-exercise-group.component.css']
})
export class NewExerciseGroupComponent extends BaseComponent {

  public weight: IWeight;

  constructor(private _service: ExerciseGroupService, router: Router) {

    super(router);

    this.weight = {
      stone: 11,
      pounds: 5
    }
  }

  onSubmit() {
    this.submit(() => {
      return this._service.add(this.recorded, this.weight)          
        .subscribe(
          () => {
            this.navigateTo('');
          },
          () => {
            this.errorMessage = 'Unable to process application. An error occurred on the server.';
            this.isLoading = false;
          });
    });
  }
}
