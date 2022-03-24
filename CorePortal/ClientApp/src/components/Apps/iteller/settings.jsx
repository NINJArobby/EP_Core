import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../../_metronic/layout/core";

export function ITSettings() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'ITeller Application - Settings'})}</PageTitle>
        ITELLER APPLICATION - SETTINGS
    </div>
}