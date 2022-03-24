import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../../_metronic/layout/core";

export function FIReports() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'Fimi Application - Reports'})}</PageTitle>
        FIMI APPLICATION - REPORTS
    </div>
}