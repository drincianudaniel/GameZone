import Header from "../components/Header";
import Box from "@mui/material/Box";
import AddGameForm from "../components/Forms/AddGameForm";
import AddTabbedPanel from "../components/TabbedPanels/AddTabbedPanel";

function AddPage() {
  return (
    <div>
      <Header/>
      <AddTabbedPanel/>
    </div>
  );
}

export default AddPage;
