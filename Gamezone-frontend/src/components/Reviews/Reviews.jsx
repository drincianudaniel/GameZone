import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import PostReviewForm from "../Forms/PostReviewForm";
import GamePagination from "../Pagination/GamePagination";
import Review from "./Review";

function Comments() {
  const [reviews, setReviews] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(10);
  const params = useParams();

  useEffect(() => {
    getReviews();
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
      {reviews.map((review) => {
        return (
          <Review key={review.id} review={review} getReviews={getReviews} />
        );
      })}
      <PostReviewForm id={params.id} getReviews={getReviews} />
      <GamePagination setPage={setPage} numberOfPages={numberOfPages} />
    </div>
  );
}

export default Comments;
