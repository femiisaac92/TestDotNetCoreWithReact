import React, { Component } from 'react';

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
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>                        
                    </tr>
                </thead>
                <tbody>                   
                        <tr key={movies.imdbid}>
                            <td>{movies.released}</td>
                            <td>{movies.title}</td>                         
                        </tr>
                   
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : MoviesData.renderMoviesTable(this.state.movies);

        return (
            <div>
                <h1 id="tabelLabel" >Movies</h1>
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
