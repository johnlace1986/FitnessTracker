import { Component, OnInit, Input } from '@angular/core';

import { IExerciseGroupPeriod } from '../models/exercise-group-period';

@Component({
  selector: 'ft-exercise-group',
  templateUrl: './exercise-group.component.html',
  styleUrls: ['./exercise-group.component.css']
})
export class ExerciseGroupComponent implements OnInit {

  @Input()
  public period: IExerciseGroupPeriod;

  constructor() { }

  ngOnInit() {
  }

}
