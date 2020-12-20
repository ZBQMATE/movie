import { Component, OnInit } from '@angular/core';
import { MovieService } from '../core/services/movie.service';
import { Movie } from '../shared/models/Movie';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  movies:Movie[];
  constructor(private movieService:MovieService) { }

  ngOnInit(): void {
    this.movieService.getTopRevenueMovie().subscribe(

      m=>{this.movies =m;}

    );
  }

}
