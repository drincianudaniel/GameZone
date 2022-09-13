import axios from "axios";
import React, { useEffect, useState } from "react";
import Slider from "react-slick";
import SimpleGameCard from "../Cards/SimpleGameCard";

export default function SimpleSlider() {
  const [games, setGames] = useState([]);

  useEffect(() => {
    getGames();
  }, []);

  const getGames = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_SERVERIP}/games/number/10/sort-order/latest`
      )
      .then((res) => {
        setGames(res.data);
      })
      .catch();
  };

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
    <Slider {...settings}>
      {games.map((data, i) => {
        return (
          <div key={data.id}>
            <SimpleGameCard data={data} getGames={getGames} />
          </div>
        );
      })}
    </Slider>
  );
}
