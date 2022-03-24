import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../../_metronic/layout/core";

export function CIBSettings() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'CIB Application - Settings'})}</PageTitle>
        CIB APPLICATION - SETTINGS
    </div>
}