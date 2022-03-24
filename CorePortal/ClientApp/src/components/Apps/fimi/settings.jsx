import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../../_metronic/layout/core";

export function FISettings() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'Fimi Application - Settings'})}</PageTitle>
        FIMI APPLICATION - SETTINGS
    </div>
}