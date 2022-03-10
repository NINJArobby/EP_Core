import React from 'react';
import Navbar from "./menus/Navbar";
import HeaderMobile from "./menus/HeaderMobile";
import SideMenu from "./menus/SideMenu";

export default function BaseComponent() {

    return (
        <>
            <Navbar/>
            <div className="d-flex flex-column flex-root">
                <div className="d-flex flex-row flex-column-fluid page">
                    <SideMenu/>
                </div>
            </div>
        </>
    );
}