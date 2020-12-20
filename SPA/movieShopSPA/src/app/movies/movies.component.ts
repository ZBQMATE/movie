import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';
import { Movie } from 'src/app/shared/models/Movie';
import { MovieDetails } from 'src/app/shared/models/MovieDetails';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {

  movieId: number;
  movie: MovieDetails;
  constructor( private route: ActivatedRoute,
    private movieService: MovieService) { }
    
  ngOnInit(): void {
    this.route.paramMap.subscribe(
      p=>{
        this.movieId= +p.get('id');
        this.movieService.getMovieDetails(this.movieId).subscribe(
          m=>{
            this.movie=m;
            console.log(this.movie);
          }
        )
      }
    )
  }

}
