import React from "react";
import Slider from "react-slick";
import SimpleGameCard from "../Cards/SimpleGameCard";
import SpinningLoading from "../LoadingComponents/SpinningLoading";

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
      {!props.data && <SpinningLoading />}
      {props.data && (
        <Slider {...settings}>
          {props.data.map((data, i) => {
            return (
              <React.Fragment key={data.id}>
                <SimpleGameCard data={data} />
              </React.Fragment>
            );
          })}
        </Slider>
      )}
    </>
  );
}
