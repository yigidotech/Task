import { Component, OnInit } from '@angular/core';
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
  tasks!: TaskModel[];
  taskColumns = TaskModel.columns;
  constructor(private taskService: TaskService) { }

  ngOnInit(): void {
    this.loadTask();
  }
  loadTask() {
    this.taskLoading = true;

    this.taskService.getAllTask().subscribe(
      (res) => {
        this.taskLoading = false;

        if (res) {
          this.tasks = res;

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
}
