import { Route, Routes } from "react-router";
import DefLayouts from "./components/layouts/DefLayouts";
import { useAppSelector } from "./hooks/hooks";
import LoginPage from "./pages/auth/LoginPage";
import HousePage from "./pages/HousePage/HousePage";
import NotFoundPage from "./pages/notFound/NotFoundPage";
import Housebooking from "./pages/Housebooking/HouseBooking";

const DefaultRoutes = () => {
    const { isAuth, user } = useAppSelector((state) => state.auth);

    return (
        <Routes>
            <Route path="/" element={<DefLayouts />}>
                <Route index element={<HousePage />} />
                <Route path="login" element={<LoginPage />} />
                <Route path="housebooking" element={<Housebooking/>} />
                <Route path="*" element={<NotFoundPage />} />
            </Route>
        </Routes>
    );
};
export default DefaultRoutes;