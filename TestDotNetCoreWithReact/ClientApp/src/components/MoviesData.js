import React, { Component } from 'react';
import { Link } from 'react-router-dom';
export class MoviesData extends Component {
    static displayName = MoviesData.name;

    constructor(props) {
        super(props);
        this.state = {
            movies: {}, imdbID: "",  loading: true };
    }

    componentDidMount() {
        const { match: { params } } = this.props;
        this.setState({
            imdbID: params.id
        });
        this.populateMoviesData(params.id);
    }

    static renderMoviesTable(movies) {
        return (
            <div className='col-md-12' >             
                <div className="col-md-6 p-4"  >
                        <div className="card"  >
                         <img src={movies.poster} className="card-img-top" alt={movies.title} />
                            <div className="card-body">
                                <h5 className="card-title">{movies.title}</h5>
                                <ul className="list-group list-group-flush">
                                    <li className="list-group-item">Year: {movies.year}</li>
                                    <li className="list-group-item">Type: {movies.type}</li>
                                    <li className="list-group-item"></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                <div className="col-md-5 p-4"  >
                    <div className="card"  >                       
                        <div className="card-body">
                            <h5 className="card-title">{movies.title}</h5>
                            <ul className="list-group list-group-flush">
                                <li className="list-group-item"><strong>Rated:</strong> {movies.rated}</li>
                                <li className="list-group-item"><strong>Runtime:</strong>  {movies.runtime}</li>
                                <li className="list-group-item"><strong>Genre:</strong>  {movies.genre}</li>
                                <li className="list-group-item"><strong>Director:</strong>  {movies.director}</li>
                                <li className="list-group-item"><strong>Writer:</strong>  {movies.writer}</li>
                                <li className="list-group-item"><strong>Actors:</strong>  {movies.actors}</li>
                                <li className="list-group-item"><strong>Language:</strong>  {movies.language}</li>
                                <li className="list-group-item"><strong>BoxOffice:</strong>  {movies.boxOffice}</li>
                                <li className="list-group-item"><strong>Website:</strong>  {movies.website}</li>
                                <li className="list-group-item"><strong>Ratings:</strong> 
                                     {movies.ratings.map(rating =>
                                         <div className="text-info new-line" key={rating.source}><strong>{rating.source} : </strong> {rating.value}</div>
                                     )}
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : MoviesData.renderMoviesTable(this.state.movies);

        return (
            <div>
                <h1 id="tabelLabel" >Movies</h1>
                <Link to={`/`} className="btn btn-warning btn-lg pull-right" ><i className="fa fa-arrow-left"></i> Back</Link>
                <p>Get Movies for ImdbID: {this.state.imdbID}</p>

                {contents}
            </div>
        );
    }

    async populateMoviesData(dataimdbID) {
        const response = await fetch('movies/details/?i=' + dataimdbID);
        const data = await response.json();
        this.setState({ movies: data, loading: false });
    }
}
