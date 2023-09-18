import React, { useState, useContext } from "react";
import { UserContext } from "../context/UserContext";
import { Link } from "react-router-dom";
import SideDrawer from "../components/SideDrawer";

const CreateOuting = () => {
  const [restaurant, setRestaurant] = useState("");
  const [date, setDate] = useState("");
  const [selectedHour, setSelectedHour] = useState("1");
  const [selectedMinute, setSelectedMinute] = useState("0");
  const [selectedAmPm, setSelectedAmPm] = useState("am");
  const [description, setDescription] = useState("");
  const [accompany, setAccompany] = useState(1);
  const [message, setMessage] = useState("");
  const handleSubmit = async (e) => {
    e.preventDefault();
    const minute = selectedMinute == "0" ? "00" : "30";
    const time = `${selectedHour}:${minute} ${selectedAmPm}`;
    console.log(restaurant, date, time, accompany, description);
  };

  const today = new Date();
  const minDate = today.toISOString().split("T")[0];
  const { user } = useContext(UserContext);
  if (!user) {
    return (
      <div className="pt-32 text-center">
        <h1 className="bold text-3xl mb-10">FoodieMe</h1>
        <h1 className="text-2xl">Please login..</h1>
        <Link className="text-blue-600 text-lg" to="/login">
          Login
        </Link>
      </div>
    );
  }

  return (
    <div className="p-4">
      <SideDrawer />
      <div className="max-w-md mx-auto pt-10">
        <h1 className="text-2xl mb-3 font-bold text-center">
          Create New Outing
        </h1>
        <form
          onSubmit={handleSubmit}
          className="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4 mr-2 ml-2"
        >
          <div className="mb-4">
            <label
              className="block text-gray-700 text-sm font-bold mb-2"
              htmlFor="Where"
            >
              Where?
            </label>
            <input
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              id="title"
              type="text"
              placeholder="Enter Restaurant"
              value={restaurant}
              onChange={(e) => setRestaurant(e.target.value)}
              required
            />
          </div>
          <div className="mb-6">
            <label
              className="block text-gray-700 text-sm font-bold mb-2"
              htmlFor="date"
            >
              Date
            </label>
            <input
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              id="date"
              type="date"
              placeholder="Enter your due date"
              value={date}
              onChange={(e) => setDate(e.target.value)}
              min={minDate}
              required
            />
          </div>
          <div className="mb-6">
            <label className="block text-gray-700 text-sm font-bold mb-2">
              Time
            </label>
            <div className="shadow appearance-none border rounded py-1 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline">
              <div className="flex">
                <select
                  name="hours"
                  className="bg-transparent appearance-none outline-none"
                  value={selectedHour}
                  onChange={(e) => setSelectedHour(e.target.value)}
                >
                  <option value="1">1</option>
                  <option value="2">2</option>
                  <option value="3">3</option>
                  <option value="4">4</option>
                  <option value="5">5</option>
                  <option value="6">6</option>
                  <option value="7">7</option>
                  <option value="8">8</option>
                  <option value="9">9</option>
                  <option value="10">10</option>
                  <option value="11">10</option>
                  <option value="12">12</option>
                </select>
                <span className="text-xl mr-3">:</span>
                <select
                  name="minutes"
                  className="bg-transparent appearance-none outline-none mr-4"
                  value={selectedMinute}
                  onChange={(e) => setSelectedMinute(e.target.value)}
                >
                  <option value="0">00</option>
                  <option value="30">30</option>
                </select>
                <select
                  name="ampm"
                  className="bg-transparent appearance-none outline-none"
                  value={selectedAmPm}
                  onChange={(e) => setSelectedAmPm(e.target.value)}
                >
                  <option value="am">AM</option>
                  <option value="pm">PM</option>
                </select>
              </div>
            </div>
          </div>

          <div className="mb-6">
            <label
              className="block text-gray-700 text-sm font-bold mb-2"
              htmlFor="accompany"
            >
              How many people do you want to eat with?
            </label>
            <input
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              id="accompany"
              type="number"
              placeholder="Enter your due date"
              value={accompany}
              onChange={(e) => setAccompany(e.target.value)}
              min="1"
              required
            />
          </div>

          <div className="mb-6">
            <label
              className="block text-gray-700 text-sm font-bold mb-2"
              htmlFor="description"
            >
              Description
            </label>
            <textarea
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              id="description"
              placeholder="Enter any additional information"
              value={description}
              onChange={(e) => setDescription(e.target.value)}
              rows="6"
            />
          </div>

          <div className="text-red-500 m-20 text-center">
            {message && message}
          </div>

          <div className="flex items-center justify-center">
            <button
              className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
              type="submit"
            >
              Create Your Outing!
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default CreateOuting;
