import React from "react";
import Grid from "@mui/material/Grid";
import Avatar from "@mui/material/Avatar";
import Divider from "@mui/material/Divider";
import moment from "moment";
import axios from "axios";
import MoreMenu from "../Menus/MoreMenu";
import { convertUTCDateToLocalDate } from "../../utils/TimeConverting";

const imgLink =
  "https://images.pexels.com/photos/1681010/pexels-photo-1681010.jpeg?auto=compress&cs=tinysrgb&dpr=3&h=750&w=1260";


function Review(props) {
  const handleDelete = async () => {
    await axios
      .delete(`${process.env.REACT_APP_SERVERIP}/reviews/${props.review.id}`)
      .then((response) => {
        props.getReviews();
      })
      .catch((err) => console.log(err));
  };

  return (
    <div style={{ padding: 14 }} className="App">
      <Grid container wrap="nowrap" spacing={2}>
        <Grid item>
          <Avatar alt="Remy Sharp" src={imgLink} />
        </Grid>
        <Grid justifyContent="left" item xs zeroMinWidth>
          <h4 style={{ margin: 0, textAlign: "left" }}>
            {props.review.rating}/10
          </h4>
          <h4 style={{ margin: 0, textAlign: "left" }}>
            {props.review.userName}
          </h4>
          <p style={{ textAlign: "left" }}>{props.review.content}</p>
          <p style={{ textAlign: "left", color: "gray" }}>
            {moment(
              convertUTCDateToLocalDate(new Date(props.review.createdAt))
            ).fromNow()}
          </p>
        </Grid>
        <Grid>
          <MoreMenu handleDelete={handleDelete} />
        </Grid>
      </Grid>
      <Divider variant="fullWidth" style={{ margin: "30px 0" }} />
    </div>
  );
}

export default Review;
