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
import { ExerciseGroupComponent } from './exercise-group/exercise-group.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NewExerciseGroupComponent,
    NewExerciseComponent,
    ExerciseGroupComponent
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
    ExerciseGroupComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
