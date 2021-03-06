import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NewExerciseComponent } from './new-exercise/new-exercise.component';
import { SharedModule } from './shared/shared.module';
import { ExerciseGroupModule } from './exercise-group/exercise-group.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NewExerciseComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ExerciseGroupModule,
    SharedModule,
    RouterModule.forRoot([
      { path: 'exercise', component: NewExerciseComponent },
      { path: '', pathMatch: 'full', component: HomeComponent },
      { path: '**', redirectTo: ''}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
