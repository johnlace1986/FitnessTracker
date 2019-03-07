import { Component, } from '@angular/core';
import { BaseComponent } from '../models/base.component';
import { ExerciseService } from '../services/exercise.service';
import { Router } from '@angular/router';
import { ITimeSpanWrapper } from '../models/time-span-wrapper';

@Component({
  selector: 'ft-new-exercise',
  templateUrl: './new-exercise.component.html',
  styleUrls: ['./new-exercise.component.css']
})
export class NewExerciseComponent extends BaseComponent {

  public timeTaken: ITimeSpanWrapper;
  public distance: number = 0;
  public caloriesBurned: number = 0

  constructor(private _service: ExerciseService, router: Router) {
    super(router);

    this.timeTaken = {
      days: 0,
      hours: 0,
      minutes: 0,
      seconds : 0
    };
  }

  onSubmit() {
    this.submit(() => {
      return this._service.add(this.recorded, this.timeTaken, this.distance, this.caloriesBurned)          
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
