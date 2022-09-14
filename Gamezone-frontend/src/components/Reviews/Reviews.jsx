import { Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import PostReviewForm from "../Forms/PostReviewForm";
import GamePagination from "../Pagination/GamePagination";
import Review from "./Review";

function Reviews(props) {
  const [reviews, setReviews] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);
  const params = useParams();

  useEffect(() => {
    getReviews();

    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [page]);

  const getReviews = async () => {
    await axios
      .get(
        `${process.env.REACT_APP_SERVERIP}/reviews/game/${
          params.id
        }/page/${page}/page-size/${4}`
      )
      .then((res) => {
        setReviews(res.data.data);
        setNumberOfPages(res.data.totalPages);
        console.log(res.data);
      });
  };

  return (
    <div>
      {reviews.length > 0 ? (
        reviews.map((review) => {
          return (
            <Review key={review.id} review={review} getReviews={getReviews} />
          );
        })
      ) : (
        <Typography sx={{ marginBottom: 2 }}>
          No reviews yet. Please add a review.
        </Typography>
      )}
      <PostReviewForm
        id={params.id}
        getReviews={getReviews}
        getGame={props.getGame}
      />
      <GamePagination setPage={setPage} numberOfPages={numberOfPages} />
    </div>
  );
}

export default Reviews;
