export const formatDate = (timestamp) => {
  // Create a Date object using the components
  const dateObject = new Date(timestamp);

  // Format the date as "Thursday, Aug 17, 2023"
  const options = {
    weekday: "long",
    month: "short",
    day: "numeric",
    year: "numeric",
    hour: "numeric",
    minute: "2-digit",
    hour12: true, // Use 12-hour clock
  };
  const formattedDate = dateObject.toLocaleDateString("en-US", options);

  return formattedDate;
};

export function convertToTimestamp(dateTimeString) {
  // Split the date and time parts
  const [datePart, time, ampm] = dateTimeString.split(" ");
  const [hours, minutes] = time.split(":").map(Number);

  // Parse the date
  const [year, month, day] = datePart.split("-").map(Number);

  // Create a Date object with the parsed values
  const date = new Date(year, month - 1, day, hours, minutes);

  // Adjust for PM if necessary (add 12 hours)
  if (ampm.toLowerCase() === "pm") {
    date.setHours(date.getHours() + 12);
  }

  // Convert to timestamp (milliseconds since Jan 1, 1970)
  return date;
}

export const getImage = (style) => {
  let imageUrl;
  if (style === "Italian") {
    imageUrl =
      "https://res.cloudinary.com/dmaijlcxd/image/upload/v1695425784/italian_yk7zlh.jpg";
  } else if (style === "American") {
    imageUrl =
      "https://res.cloudinary.com/dmaijlcxd/image/upload/v1695425784/american_fwrvyn.jpg";
  } else if (style === "French") {
    imageUrl =
      "https://res.cloudinary.com/dmaijlcxd/image/upload/v1695425784/french_bpwszz.jpg";
  } else if (style === "Japanese" || style === "Sushi") {
    imageUrl =
      "https://res.cloudinary.com/dmaijlcxd/image/upload/v1695425784/japanese_jnbf4b.jpg";
  } else if (style === "Pizza") {
    imageUrl =
      "https://res.cloudinary.com/dmaijlcxd/image/upload/v1695425784/pizza_mmlkzf.jpg";
  } else {
    imageUrl =
      "https://res.cloudinary.com/dmaijlcxd/image/upload/v1670714078/samples/food/pot-mussels.jpg";
  }
  return imageUrl;
};
