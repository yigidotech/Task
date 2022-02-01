import { Component, OnInit } from '@angular/core';
import { MatCheckbox, MatCheckboxChange } from '@angular/material/checkbox';
import { TaskModel } from '../models/task.model';
import { TaskService } from './task.service';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {
  showAlert: boolean = false;
  taskLoading: boolean = false;
  completedTasks!: TaskModel[];
  uncompletedTasks!: TaskModel[];
  taskColumns = TaskModel.columns;
  selectedTask!: TaskModel;

  constructor(private taskService: TaskService) { }

  ngOnInit(): void {
    this.loadTask();
  }

  loadTask() {
    this.taskLoading = true;

    this.taskService.getAllTasksByIsCompleted(true).subscribe(
      (res) => {
        this.taskLoading = false;

        if (res) {
          this.completedTasks = res;

        } else {
          this.showAlert = true;
        }
      },
      (error) => {
        this.taskLoading = false;
        console.log(error);

      }
    );
    this.taskService.getAllTasksByIsCompleted(false).subscribe(
      (res) => {
        this.taskLoading = false;

        if (res) {
          this.uncompletedTasks = res;

        } else {
          this.showAlert = true;
        }
      },
      (error) => {
        this.taskLoading = false;
        console.log(error);
      }
    );
  }

  rowClicked(task: TaskModel) {
    this.selectedTask = task;
  }

  getColor(index: number): string {
    let result: string = '';
    switch (index % 2) {
      case 0: {
        result = '#d9ffb3';
        break;
      }
      case 1: {
        result = '#f2ffe6';
        break;
      }
    }
    return result;
  }

  getComplatedColor(index: number): string {
    let result: string = '';
    switch (index % 2) {
      case 0: {
        result = '#80dfff';
        break;
      }
      case 1: {
        result = '#ccf2ff';
        break;
      }
    }
    return result;
  }

  completeChanged(matCheckbox: MatCheckboxChange,task: TaskModel) {
    task.isCompleted = matCheckbox.checked;
    this.taskService.changeTaskComplete(task).subscribe(
      (res) => {
        this.loadTask();
      }, (error) => {
        debugger;
      });
  }

}
