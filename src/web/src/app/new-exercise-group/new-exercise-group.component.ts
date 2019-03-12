import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { BaseComponent } from '../models/base.component';
import { IExerciseGroup } from '../models/exercise-group';
import { IWeight } from '../models/weight';
import { ExerciseGroupService } from '../services/exercise-group.service';

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
    this.submit<IExerciseGroup>(
      this._service.add(this.recorded, this.weight),
      () => {
        this.navigateTo('');
      });
  }
}
