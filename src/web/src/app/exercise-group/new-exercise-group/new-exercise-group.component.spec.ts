import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewExerciseGroupComponent } from './new-exercise-group.component';

describe('NewExerciseGroupComponent', () => {
  let component: NewExerciseGroupComponent;
  let fixture: ComponentFixture<NewExerciseGroupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewExerciseGroupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewExerciseGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
