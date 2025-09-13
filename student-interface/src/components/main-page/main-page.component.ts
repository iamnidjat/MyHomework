import {Component, inject, OnInit} from '@angular/core';
import {CrudOpersService} from '../../services/crud-opers.service';
import {ActivatedRoute, RouterLink} from '@angular/router';
import {Group} from '../../models/group';

@Component({
  selector: 'app-main-page',
  imports: [
    RouterLink
  ],
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.css',
  standalone: true
})
export class MainPageComponent implements OnInit {
  private crudOpersService: CrudOpersService = inject(CrudOpersService);
  private route = inject(ActivatedRoute);

  public allGroups: Group[] = [];
  public studentGroups: Group[] = [];

  constructor() {
  }

  public getStudentGroups(id: number) {
    this.crudOpersService.getStudentGroups(id).subscribe({
      next: (response) => {
        console.log(response);
        this.studentGroups = response;
      },
      error: (err) => {
        console.error(err);
      },
    })
  }

  public getAllGroups() {
    this.crudOpersService.getAllGroups().subscribe({
      next: (response) => {
        console.log(response);
        this.allGroups = response;
      },
      error: (err) => {
        console.error(err);
      },
    })
  }

  ngOnInit(): void {
    const studentId = Number(this.route.snapshot.paramMap.get('id'));
    this.getStudentGroups(studentId);
    this.getAllGroups();
  }
}
