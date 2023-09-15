import React, { Component } from "react";
import { Route, Routes } from "react-router-dom";

import Index from "./pages/Index";
import Login from "./pages/Login";
import Signup from "./pages/Singup";
import Dashboard from "./pages/Dashboard";
import CreateOuting from "./pages/CreateOuting";
import ViewOuting from "./pages/ViewOuting";
import ViewRestaurant from "./pages/ViewRestaurant";

export default class App extends Component {
  static displayName = App.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map((forecast) => (
            <tr key={forecast.date}>
              <td>{forecast.date}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading ? (
      <p>
        <em>
          Loading... Please refresh once the ASP.NET backend has started. See{" "}
          <a href="https://aka.ms/jspsintegrationreact">
            https://aka.ms/jspsintegrationreact
          </a>{" "}
          for more details.
        </em>
      </p>
    ) : (
      App.renderForecastsTable(this.state.forecasts)
    );

    return (
      <div>
        <Routes>
          <Route path="/" element={<Index />}></Route>
          <Route path="/login" element={<Login />}></Route>
          <Route path="/signup" element={<Signup />}></Route>
          <Route path="/dashboard" element={<Dashboard />}></Route>
          <Route path="/create-outing" element={<CreateOuting />} />
          <Route path="/view-outing" element={<ViewOuting />} />
          <Route path="/view-restaurant" element={<ViewRestaurant />} />
        </Routes>
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch("weatherforecast");
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
