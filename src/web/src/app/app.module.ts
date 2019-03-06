import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NewExerciseGroupComponent } from './new-exercise-group/new-exercise-group.component';
import { NewExerciseComponent } from './new-exercise/new-exercise.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NewExerciseGroupComponent,
    NewExerciseComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'group', component: NewExerciseGroupComponent },
      { path: 'exercise', component: NewExerciseComponent },
      { path: '', pathMatch: 'full', component: HomeComponent },
      { path: '**', redirectTo: ''}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
