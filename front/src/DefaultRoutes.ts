import { Route, Routes } from "react-router";

const DefaultRoutes = () => {
    return (
        <Routes>
            <Route path="*" element={<div>Default Route: Page Not Found</div>} />
        </Routes>
    );
};
export default DefaultRoutes;