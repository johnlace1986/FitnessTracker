import { Component, OnInit, Input } from '@angular/core';
import { IExerciseGroupSummary } from '../models/exercise-group-summary';

@Component({
  selector: 'ft-exercise-group',
  templateUrl: './exercise-group.component.html',
  styleUrls: ['./exercise-group.component.css']
})
export class ExerciseGroupComponent implements OnInit {

  @Input()
  public group: IExerciseGroupSummary;

  constructor() { }

  ngOnInit() {
  }

}
