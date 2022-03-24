import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../../_metronic/layout/core";

export function ITReports() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'ITeller Application - Reports'})}</PageTitle>
        ITELLER APPLICATION - REPORTS
    </div>
}