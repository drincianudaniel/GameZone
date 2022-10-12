import React from "react";
import Grid from "@mui/material/Grid";
import Divider from "@mui/material/Divider";
import moment from "moment";
import { convertUTCDateToLocalDate } from "../../utils/TimeConverting";
import { Link } from "react-router-dom";
import { Typography } from "@mui/material";
import { Box } from "@mui/system";

function ProfileReview(props) {
  return (
    <div style={{ padding: 1 }} className="App">
      <Grid container wrap="nowrap" spacing={2}>
        <Grid item xs sx={{}}>
          <Box
            sx={{
              display: "flex",
              justifyContent: "space-between",
              alignItems: "center",
            }}
          >
            <Link
              style={{ textDecoration: "none", color: "inherit" }}
              to={`/game/${props.review.gameId}/reviews`}
            >
              <Typography
                sx={{
                  margin: 0,
                  textAlign: "left",
                  fontWeight: "bold",
                  cursor: "pointer",
                  "&:hover": {
                    color: "primary.main",
                  },
                }}
              >
                {props.review.gamename}
              </Typography>
            </Link>
            <Typography sx={{ margin: 0, fontWeight: "bold" }}>
              {props.review.rating}/10
            </Typography>
          </Box>
          <p style={{ textAlign: "left" }}>{props.review.content}</p>
          <p style={{ textAlign: "left", color: "gray" }}>
            {moment(
              convertUTCDateToLocalDate(new Date(props.review.createdAt))
            ).fromNow()}
          </p>
        </Grid>
      </Grid>
      <Divider variant="fullWidth" style={{ margin: "30px 0" }} />
    </div>
  );
}

export default ProfileReview;
