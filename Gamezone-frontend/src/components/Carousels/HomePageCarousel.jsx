import { CircularProgress } from "@mui/material";
import { Box } from "@mui/system";
import React from "react";
import Slider from "react-slick";
import SimpleGameCard from "../Cards/SimpleGameCard";

export default function HomePageCarousel(props) {
  var settings = {
    arrows: false,
    infinite: true,
    speed: 500,
    slidesToShow: 4,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 5000,
    centerMode: true,
    responsive: [
      {
        breakpoint: 1600,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 1,
          infinite: true,
        },
      },
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 1,
          infinite: true,
        },
      },
      {
        breakpoint: 600,
        settings: {
          slidesToShow: 2,
        },
      },
      {
        breakpoint: 480,
        settings: {
          slidesToShow: 1,
        },
      },
    ],
  };

  return (
    <>
      {!props.data && (
        <Box
          sx={{
            width: "100%",
            display: "flex",
            justifyContent: "center",
            mt: 3,
            mb: 3,
          }}
        >
          <CircularProgress />
        </Box>
      )}
      {props.data && (
        <Slider {...settings}>
          {props.data.map((data, i) => {
            return (
              <div key={data.id}>
                <SimpleGameCard data={data} />
              </div>
            );
          })}
        </Slider>
      )}
    </>
  );
}
