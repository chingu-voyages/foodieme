export const formatDate = (dateString) => {
  const dateComponents = dateString.split("-");

  // Create a Date object using the components
  const dateObject = new Date(
    parseInt(dateComponents[0]), // Year
    parseInt(dateComponents[1]) - 1, // Month (0-based, so subtract 1)
    parseInt(dateComponents[2]) // Day
  );

  // Format the date as "Thursday, Aug 17, 2023"
  const options = {
    weekday: "long",
    month: "short",
    day: "numeric",
    year: "numeric",
  };
  const formattedDate = dateObject.toLocaleDateString("en-US", options);

  return formattedDate;
};
