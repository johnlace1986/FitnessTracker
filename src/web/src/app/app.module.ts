import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NewExerciseGroupComponent } from './new-exercise-group/new-exercise-group.component';
import { NewExerciseComponent } from './new-exercise/new-exercise.component';
import { SharedModule } from './shared/shared.module';
import { ExerciseGroupPeriodComponent } from './exercise-group-period/exercise-group-period.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NewExerciseGroupComponent,
    NewExerciseComponent,
    ExerciseGroupPeriodComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    SharedModule,
    RouterModule.forRoot([
      { path: 'group', component: NewExerciseGroupComponent },
      { path: 'exercise', component: NewExerciseComponent },
      { path: '', pathMatch: 'full', component: HomeComponent },
      { path: '**', redirectTo: ''}
    ])
  ],
  exports: [
    ExerciseGroupPeriodComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
