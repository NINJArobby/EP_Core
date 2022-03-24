import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../../_metronic/layout/core";

export function CIBReports() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'CIB Application - Reports'})}</PageTitle>
        GLOBALPAY APP
    </div>
}