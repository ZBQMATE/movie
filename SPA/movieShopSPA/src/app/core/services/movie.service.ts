import { Injectable } from '@angular/core';
import { Movie } from 'src/app/shared/models/movie';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { MovieDetails } from 'src/app/shared/models/movieDetails';
@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private apiService: ApiService) { }

  getTopRevenueMovie(): Observable<Movie[]>{
   return this.apiService.getAll('Movies/toprevenue')
  }
  getMovieDetails(id:number):Observable<MovieDetails>{

    return this.apiService.getOne('Movies',id)

  }
  getMovieByGenre(id:number):Observable<Movie[]>{
    return this.apiService.getAll('movies/genre', id)
  }
}
