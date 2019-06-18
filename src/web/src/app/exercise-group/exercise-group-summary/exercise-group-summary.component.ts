import { Component, OnInit, Input } from '@angular/core';
import { IExerciseGroupSummary } from 'src/app/models/exercise-group-summary';
import { IExerciseGroupResult } from 'src/app/models/exercise-group-result';
import { ExerciseGroupService } from 'src/app/services/exercise-group.service';
import { WeightDisplayFormat } from 'src/app/models/weight-display-format';

@Component({
  selector: 'ft-exercise-group-summary',
  templateUrl: './exercise-group-summary.component.html',
  styleUrls: ['./exercise-group-summary.component.css']
})
export class ExerciseGroupSummaryComponent implements OnInit {

  @Input()
  public summary: IExerciseGroupSummary;
  public group: IExerciseGroupResult = null;
  public weightDisplayFormat: WeightDisplayFormat = WeightDisplayFormat.Stones;

  constructor(private service: ExerciseGroupService) {  }

  ngOnInit() {
  }

  enumerate(n: number): any[] {
    return Array(n);
  }

  getSummaryPanelId() {
    return `summary${this.summary.id}`;
  }

  toggleIsExpanded() {
    this.summary.isExpanded = !this.summary.isExpanded

    if (this.summary.isExpanded && this.group === null) {
      this.service.getById(this.summary.id)
        .subscribe(group => {
          this.group = group;    
        });
    }
  }

  toggleWeightDisplayFormat() {    
    switch(this.weightDisplayFormat) {
      case WeightDisplayFormat.Stones:
        this.weightDisplayFormat = WeightDisplayFormat.StonesFraction;
        break;
      case WeightDisplayFormat.StonesFraction:
        this.weightDisplayFormat = WeightDisplayFormat.Pounds;
        break;
      case WeightDisplayFormat.Pounds:
        this.weightDisplayFormat = WeightDisplayFormat.Kilograms;
        break;
      case WeightDisplayFormat.Kilograms:
        this.weightDisplayFormat = WeightDisplayFormat.Stones;
        break;
    }
  }
}
