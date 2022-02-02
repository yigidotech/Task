import { Component, OnInit } from '@angular/core';
import { MatCheckbox, MatCheckboxChange } from '@angular/material/checkbox';
import { AlertTypeModel } from '../models/alert-types.model';
import { TaskModel } from '../models/task.model';
import { TaskService } from './task.service';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {
  showAlert: boolean = false;
  alertType: string = AlertTypeModel.danger;
  alertMessage!: string;
  taskLoading: boolean = false;
  completedTasks!: TaskModel[];
  uncompletedTasks!: TaskModel[];
  taskColumns = TaskModel.columns;
  selectedTask!: TaskModel;
  task = new TaskModel();
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
          this.alertType = AlertTypeModel.danger;
        }
      },
      (error) => {
        this.taskLoading = false;
        this.showAlert = true;
        this.alertType = AlertTypeModel.danger;
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
          this.alertType = AlertTypeModel.danger;
        }
      },
      (error) => {
        this.taskLoading = false;
        this.showAlert = true;
        this.alertType = AlertTypeModel.danger;
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

  completeChanged(matCheckbox: MatCheckboxChange, task: TaskModel) {
    task.isCompleted = matCheckbox.checked;
    this.taskService.changeTaskComplete(task).subscribe(
      (res) => {
        this.loadTask();

        this.alertType = AlertTypeModel.success;
        this.showAlert = true;
        if (task.isCompleted) {
          this.alertMessage = 'Görev tamamlandı olarak kayıt edildi.'
        } else {
          this.alertMessage = 'Görev yapılacak olarak kayıt edildi.'
        }

      }, (error) => {
        this.showAlert = true;
        this.alertMessage = 'Kayıt yapılamadı.'
        this.alertType = AlertTypeModel.danger;
        console.log(error);
      });
  }

  save() {
    if (this.task && this.task.title && this.task.description) {
      this.task.createdBy = 1;
      this.taskService.createdTask(this.task).subscribe((res) => {
        this.loadTask();
        this.showAlert = true;
        this.alertMessage = 'Görev oluşturuldu.'
        this.alertType = AlertTypeModel.success;
      }, (error) => {
        this.showAlert = true;
        this.alertMessage = 'Görev kaydedilemedi.'
        this.alertType = AlertTypeModel.danger;
      });
    }

  }
}
