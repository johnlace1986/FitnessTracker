import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { BaseComponent } from '../models/base.component';
import { IExercise } from '../models/exercise';
import { ITimeSpanWrapper } from '../models/time-span-wrapper';
import { ExerciseService } from '../services/exercise.service';

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
    this.submit<IExercise>(
      this._service.add(this.recorded, this.timeTaken, this.distance, this.caloriesBurned),
      () => {
        this.navigateTo('');
      });
  }
}
