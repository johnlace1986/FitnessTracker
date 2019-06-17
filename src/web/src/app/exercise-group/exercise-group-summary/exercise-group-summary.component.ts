import { Component, OnInit, Input } from '@angular/core';
import { IExerciseGroupSummary } from 'src/app/models/exercise-group-summary';
import { IExerciseGroupResult } from 'src/app/models/exercise-group-result';
import { ExerciseGroupService } from 'src/app/services/exercise-group.service';

@Component({
  selector: 'ft-exercise-group-summary',
  templateUrl: './exercise-group-summary.component.html',
  styleUrls: ['./exercise-group-summary.component.css']
})
export class ExerciseGroupSummaryComponent implements OnInit {

  @Input()
  public summary: IExerciseGroupSummary;
  public group: IExerciseGroupResult = null;

  constructor(private service: ExerciseGroupService) { }

  ngOnInit() {
  }

  enumerate(n: number): any[] {
    return Array(n);
  }

  toggleExpanded() {
    var header = document.getElementById('summaryHeader' + this.summary.id);
    
    //property changes before UI updates so we need to use the inverse of aria-expanded
    this.summary.isExpanded = header.getAttribute('aria-expanded') !== 'true'; 

    if (this.summary.isExpanded && this.group === null) {
      this.service.getById(this.summary.id)
        .subscribe(group => {
          this.group = group;    
        });
    }
  }
}
