import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskUpdatePartialComponent } from './task-update-partial.component';

describe('TaskUpdatePartialComponent', () => {
  let component: TaskUpdatePartialComponent;
  let fixture: ComponentFixture<TaskUpdatePartialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TaskUpdatePartialComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskUpdatePartialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
