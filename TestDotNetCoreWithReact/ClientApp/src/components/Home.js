import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './bootstrap.css';
export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
        super(props);
      this.state = { searchInput: "", Message: "", movies: [], result:"" };
      this.handleChange = this.handleChange.bind(this);
      this.Search = this.search.bind(this);
  }

  handleChange(event) { this.setState({ searchInput: event.target.value }); }
    async search(event) {
        event.preventDefault();
        if (this.state.searchInput === "") {
            this.setState({
                Message: "Please type a search term"
            });
        } else {
            this.setState({ loading: true });
            await this.populateMoviesData();
            if (this.state.movies.length > 0) {
                let contents = this.state.loading
                    ? <p><em>Searching movies...</em></p>
                    : Home.renderMovies(this.state.movies);
                this.setState({
                    Message: "Search Result",
                    result: contents
                });
            }
        }
    }
    static renderMovies(movies) {
        return (
            <div className='col-md-12' >                                                
                {movies.map(movie =>
                    <div className="col-md-4 p-4" key={movie.imdbID}  >
                        <div className="card"  >
                        <img src={movie.poster} className="card-img-top"  alt={movie.title}  />
                                <div className="card-body">
                                    <h5 className="card-title">{movie.title}</h5>
                                    <ul className="list-group list-group-flush">
                                        <li className="list-group-item">Year: {movie.year}</li>
                                        <li className="list-group-item">Type: {movie.type}</li>
                                        <li className="list-group-item"></li>
                                </ul>
                                <Link to={`/movies-data/${movie.imdbID}`} className="btn btn-primary btn-lg pull-right" ><i className="fa fa-eye"></i> Details</Link>
                                
                                </div>
                            </div>
                    </div>
                    )}                
            </div>
        );
    }
  async populateMoviesData(search) {
        const response = await fetch('movies/get?s=' + this.state.searchInput);
        const data = await response.json();
        this.setState({ movies: data, loading: false });
  }
  render () {
    return (
      <div>
        <h1>Movies, <small>EveryWhere AnyTime</small></h1>
            <div className="row">
                <div className="col-md-12 mt-6">
                    <form onSubmit={this.Search}>
                        <input type="text" placeholder="Search..." value={this.state.searchInput} onChange={this.handleChange} className="form-control col-md-10" />
                        <button className="btn btn-warning ml-2"><i className="fa fa-search"></i> Search</button>
					</form>
                </div>
                <div className="col-md-12">
                    <p aria-live="polite"><strong>{this.state.Message}</strong></p>                    
                </div>
                <div className="row">
                    {this.state.result}
                </div>
            </div>           
        </div>
    );
  }
}
