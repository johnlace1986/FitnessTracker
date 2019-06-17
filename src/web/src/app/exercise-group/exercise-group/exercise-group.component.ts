import { Component, OnInit, Input } from '@angular/core';

import { IExerciseGroupResult } from 'src/app/models/exercise-group-result';

@Component({
  selector: 'ft-exercise-group',
  templateUrl: './exercise-group.component.html',
  styleUrls: ['./exercise-group.component.css']
})
export class ExerciseGroupComponent implements OnInit {

  @Input()
  public group: IExerciseGroupResult;
  
  constructor() { }

  ngOnInit() {
  }

}
