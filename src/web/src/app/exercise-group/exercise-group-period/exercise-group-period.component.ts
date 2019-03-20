import { Component, OnInit, Input } from '@angular/core';
import { IExerciseGroupPeriod } from '../../models/exercise-group-period';

@Component({
  selector: 'ft-exercise-group-period',
  templateUrl: './exercise-group-period.component.html',
  styleUrls: ['./exercise-group-period.component.css']
})
export class ExerciseGroupPeriodComponent implements OnInit {

  @Input()
  public period: IExerciseGroupPeriod;

  constructor() { }

  ngOnInit() {
  }

}
