import { Component, OnInit } from '@angular/core';
import { ExerciseGroupService } from '../services/exercise-group.service';
import { IExerciseGroup } from '../models/exercise-group';

@Component({
  selector: 'ft-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public errorMessage: string;
  public groups: Array<IExerciseGroup>;

  constructor(private _service: ExerciseGroupService) { }

  ngOnInit() {
    this.errorMessage = '';

    this._service.get()
      .subscribe(groups => {
        this.groups = groups;
      },
      () => {
        this.errorMessage = 'Unable to load data. An error occurred on the server.'
      });
  }
}
