import { Box, Grid } from "@mui/material";
import { useEffect } from "react";
import { useState } from "react";
import { useParams } from "react-router";
import UserService from "../../api/UserService";
import ProfileReview from "../Reviews/ProfileReview";

export default function UserReviews() {
  const [reviews, setReviews] = useState([]);
  const params = useParams();

  useEffect(() => {
    getReviews();
  }, [params]);

  const getReviews = () => {
    UserService.GetUserReviews(params.username).then((res) => {
      setReviews(res.data);
    });
  };

  return (
    <Box sx={{ width: "100%", display: "flex", justifyContent: "center" }}>
      <Grid container spacing={1}>
        {reviews.map((review) => {
          return (
            <Grid key={review.id} item xs={12} sm={12} md={12}>
              <ProfileReview review={review} />
            </Grid>
          );
        })}
      </Grid>
    </Box>
  );
}
