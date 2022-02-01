import { Component, Input, OnInit } from '@angular/core';
import { TaskModel } from 'src/app/models/task.model';
import { TaskService } from '../../task.service';

@Component({
  selector: 'app-task-update-partial',
  templateUrl: './task-update-partial.component.html',
  styleUrls: ['./task-update-partial.component.css']
})
export class TaskUpdatePartialComponent implements OnInit {
  @Input() task!: TaskModel;
  showAlert: boolean = false;
  constructor(private taskService: TaskService) { }
  alertMessage = "";
  ngOnInit(): void {
  }

  updateTask() {
    this.taskService.updateTask(this.task.id, this.task).subscribe(
      (res) => {
        this.alertMessage = "Kayıt başarılı.";
        this.showAlert = true;
      },
      (error) => {
        this.alertMessage = "Hata";
        this.showAlert = true;
        console.log(error);
      }
    );
  }

  deleteTask() {
    this.taskService.deleteTask(this.task.id).subscribe(
      (res) => {
        this.alertMessage = "Kayıt silindi.";
        this.showAlert = true;
      },
      (error) => {
        this.alertMessage = "Hata";
        this.showAlert = true;
        console.log(error);
      }
    );
  }

}
