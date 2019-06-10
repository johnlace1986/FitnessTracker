import { Component, OnInit, Input } from '@angular/core';
import { IExerciseGroupSummary } from 'src/app/models/exercise-group-summary';

@Component({
  selector: 'ft-exercise-group-summary',
  templateUrl: './exercise-group-summary.component.html',
  styleUrls: ['./exercise-group-summary.component.css']
})
export class ExerciseGroupSummaryComponent implements OnInit {

  @Input()
  public summary: IExerciseGroupSummary;

  constructor() { }

  ngOnInit() {
  }

  enumerate(n: number): any[] {
    return Array(n);
  }
}
