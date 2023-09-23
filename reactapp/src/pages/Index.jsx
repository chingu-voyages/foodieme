import React from "react";
import { useNavigate } from "react-router-dom";

const Index = () => {
  const navigate = useNavigate();
  const moveToSignup = () => {
    navigate("/signup");
  };
  return (
    <div className="text-center pt-32">
      <h1 className="font-extrabold text-[50px] w-full">FoodieMe</h1>
      <p className="w-2/3 max-w-md my-10 mx-auto">
        Ever wanted to try a restaurant and meet new people at the same time?
        Create a foodie outing and find people who want to join you, or hop into
        another person's meal plans.
      </p>
      <img
        src="https://res.cloudinary.com/dmaijlcxd/image/upload/v1694817850/eatout_jpw5gh.webp"
        className="w-2/3 max-w-lg min-w-[280px] mx-auto my-10"
        alt="Cheering over pizzas on the table"
      ></img>
      <button
        className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 mb-4 px-4 rounded focus:outline-none focus:shadow-outline"
        type="button"
        onClick={moveToSignup}
      >
        Sign up Today{" "}
      </button>
    </div>
  );
};

export default Index;
