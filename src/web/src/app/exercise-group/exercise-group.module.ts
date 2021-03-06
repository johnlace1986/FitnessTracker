import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { NewExerciseGroupComponent } from './new-exercise-group/new-exercise-group.component';
import { ExerciseGroupPeriodComponent } from './exercise-group-period/exercise-group-period.component';
import { SharedModule } from '../shared/shared.module';
import { ExerciseGroupSummaryComponent } from './exercise-group-summary/exercise-group-summary.component';
import { ExerciseGroupComponent } from './exercise-group/exercise-group.component';

@NgModule({
  declarations: [
    NewExerciseGroupComponent,
    ExerciseGroupPeriodComponent,
    ExerciseGroupSummaryComponent,
    ExerciseGroupComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    RouterModule.forChild([      
      { path: 'group', component: NewExerciseGroupComponent }
    ])
  ],
  exports: [
    ExerciseGroupPeriodComponent,
    ExerciseGroupSummaryComponent,
    ExerciseGroupComponent
  ]
})
export class ExerciseGroupModule { }
