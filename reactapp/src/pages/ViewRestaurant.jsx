import React, { useContext, useState, useEffect } from "react";
import OutingCard from "../components/OutingCard";
import SideDrawer from "../components/SideDrawer";
import { UserContext } from "../context/UserContext";
import { Link, useParams } from "react-router-dom";
import { baseUrl } from "../constant";
import axios from "axios";
import { getImage } from "../utils/utils";

const ViewRestaurant = () => {
  const { user, headers } = useContext(UserContext);
  const { id } = useParams();
  const [restaurantData, setRestaurantData] = useState([]);
  useEffect(() => {
    const fetchData = async () => {
      try {
        const res = await axios.get(`${baseUrl}/api/Restaurants/${id}`, {
          headers: headers,
        });
        console.log(res.data);
        setRestaurantData(res.data);
      } catch (err) {
        console.log(err);
      }
    };
    fetchData();
  }, []);
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
    <div className="text-center">
      <SideDrawer />
      <h1 className="text-4xl m-5">{restaurantData?.Name}</h1>
      <div>
        <img
          className="w-2/3 mx-auto max-w-[500px] m-10"
          src={restaurantData.Style && getImage(restaurantData.Style)}
        ></img>
      </div>
      <h2 className="text-xl m-5">{restaurantData?.Address}</h2>

      <div>
        <h2 className="text-2xl text-left text-bold m-5">Who's eating here?</h2>
        {/* ask the restaurant data include outing data */}
        {/* <div>
          {sampleData.outings.map((outing, index) => {
            return <OutingCard key={index} outing={outing} />;
          })}
        </div> */}
      </div>
    </div>
  );
};

export default ViewRestaurant;
