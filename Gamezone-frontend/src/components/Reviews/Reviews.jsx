import { Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import { Link } from "react-router-dom";
import { useUser } from "../../hooks/useUser";
import PostReviewForm from "../Forms/PostReviewForm";
import SpinningLoading from "../LoadingComponents/SpinningLoading";
import GamePagination from "../Pagination/GamePagination";
import Review from "./Review";

function Reviews(props) {
  const [reviews, setReviews] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);
  const params = useParams();
  const { user } = useUser();
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
        setIsLoading(false);
      });
  };

  return (
    <>
      {isLoading ? (
        <SpinningLoading />
      ) : reviews.length > 0 ? (
        reviews.map((review) => {
          return (
            <Review
              key={review.id}
              review={review}
              getReviews={getReviews}
              getGame={props.getGame}
            />
          );
        })
      ) : (
        <Typography sx={{ marginBottom: 2 }}>
          No reviews yet. Please add a review.
        </Typography>
      )}

      {user.IsLoggedIn && (
        <PostReviewForm
          id={params.id}
          getReviews={getReviews}
          getGame={props.getGame}
        />
      )}
      {!user.IsLoggedIn && (
        <Typography sx={{ mb: 2 }}>
          You have to be{" "}
          <Link to={"/login"}>
            <Typography sx={{ display: "inline", color: "primary.main" }}>
              logged in
            </Typography>
          </Link>{" "}
          to post a review.
        </Typography>
      )}
      <GamePagination setPage={setPage} numberOfPages={numberOfPages} />
    </>
  );
}

export default Reviews;
